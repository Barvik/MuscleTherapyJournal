using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using log4net;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;

namespace MuscleTherapyJournal.Controllers.WebApi
{
    [RoutePrefix("api/treatment")]
    public class TreatmentApiController : ApiController
    {
        private readonly ITreatmentService _treatmentService;
        private readonly ICustomerService _customerService;
        private readonly IAreaAfflicationService _areaAfflicationService;

        private readonly ILog _logger = LogManager.GetLogger(typeof(TreatmentApiController));

        public TreatmentApiController(ITreatmentService treatmentService, ICustomerService customerService, IAreaAfflicationService areaAfflicationService)
        {
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");
            if (customerService == null) throw new ArgumentNullException("customerService");
            if (areaAfflicationService == null) throw new ArgumentNullException("areaAfflicationService");

            _treatmentService = treatmentService;
            _customerService = customerService;
            _areaAfflicationService = areaAfflicationService;
        }

        [HttpPost]
        [Route("savetreatment")]
        public IHttpActionResult SaveTreatment(SaveTreatmentApiModel model)
        {
            var afflications = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AfflictionArea>>(model.Afflication);
            var deleteAfflication = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AfflictionArea>>(model.DeleteAffliction);
            var observations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(model.Observations);
            var anamnesis = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(model.Anamnesis);
            var treatmentNotes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(model.TreatmentNotes);

            bool deleteAfflictionResult = _areaAfflicationService.DeleteAfflications(deleteAfflication);
            if (!deleteAfflictionResult)
            {
                _logger.ErrorFormat("Unable to delete afflictions");
            }

            var newTreatment = model.TreatmentId == 0;

            var observationsAsTextArea = SetupAsTextArea(observations);
            var anamnesisAsTextArea = SetupAsTextArea(anamnesis);
            var treatmentNotesAsTextArea = SetupAsTextArea(treatmentNotes);

            afflications.RemoveAll(x => x.IsPersisted);

            var oldAfflications = _areaAfflicationService.GetAfflicationAreasByCustomerId(model.CustomerId);
            var newAfflications = new List<AfflictionArea>();
            if (oldAfflications != null && oldAfflications.Any())
            {
                foreach (var afflictionArea in afflications)
                {
                    var isPersisted =
                        oldAfflications.Exists(
                            x =>
                                x.MouseXPosition == afflictionArea.MouseXPosition &&
                                x.MouseYPosition == afflictionArea.MouseXPosition);

                    if (!isPersisted)
                    {
                        newAfflications.Add(afflictionArea);
                    }
                }
            }
            else
            {
                newAfflications = afflications;
            }

            foreach (var afflictionArea in newAfflications)
            {
                afflictionArea.CreatedDate = DateTime.Now;
                afflictionArea.TreatmentId = model.TreatmentId;
                afflictionArea.CustomerId = model.CustomerId;
            }

            var treatment = _treatmentService.GetTreatmentById(model.TreatmentId);

            if (treatment == null)
            {
                treatment = new Treatment
                {
                    CreatedDate = DateTime.Now,
                    UserId = 1,
                    CustomerId = model.CustomerId
                };
            }

            treatment.AfflictionAreas = newAfflications;
            treatment.Anamnesis = anamnesisAsTextArea;
            treatment.ChangedDate = DateTime.Now;
            treatment.TreatmentNotes = treatmentNotesAsTextArea;
            treatment.Observations = observationsAsTextArea;
            treatment.UserId = 1;

            var treatmentId = _treatmentService.SaveTreatment(treatment, newTreatment);
            //var persistedAfflictions = new OldAfflications
            //{
            //    Afflications = _areaAfflicationService.GetAfflicationAreasByTreatmentId(treatmentId),
            //    TreatmentId = treatmentId
            //};
            
            //if (persistedAfflictions.Afflications != null && persistedAfflictions.Afflications.Any())
            //{
            //    foreach (var persistedAffliction in persistedAfflictions.Afflications)
            //    {
            //        persistedAffliction.IsPersisted = true;
            //    }
            //}

            return Ok(treatmentId);
            //return Ok(persistedAfflictions);
        }

        private string SetupAsTextArea(IEnumerable<string> textAreaList)
        {
            var result = "";

            if (textAreaList == null)
            {
                return result;
            }
            foreach (var text in textAreaList)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    result += "\r\n";
                }
                else
                {
                    result += text + "\r\n";
                }
            }

            return result;
        }

        public string Get()
        {
            return "Hello world";
        }
    }

    public class AfflicationModel
    {
        public buttonType ButtonType { get; set; }
        public pos Pos { get; set; }

    }

    public class buttonType
    {
        public string name { get; set; }
        public int value { get; set; } 
        public int enumValue { get; set; } 
    }

    public class pos
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class SaveTreatmentApiModel
    {
        public string Afflication { get; set; }
        public string DeleteAffliction { get; set; }
        public string TreatmentNotes { get; set; }
        public string Observations { get; set; }
        public string Anamnesis { get; set; }
        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
    }
}
