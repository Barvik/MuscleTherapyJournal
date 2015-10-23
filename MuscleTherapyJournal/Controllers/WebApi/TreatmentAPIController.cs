using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI.WebControls;
using MuscleTherapyJournal.Core.Services.Interfaces;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Models;

namespace MuscleTherapyJournal.Controllers.WebApi
{
    [RoutePrefix("api/treatment")]
    public class TreatmentApiController : ApiController
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentApiController(ITreatmentService treatmentService)
        {
            if (treatmentService == null) throw new ArgumentNullException("treatmentService");

            _treatmentService = treatmentService;
        }

        [HttpPost]
        [Route("savetreatment")]
        public IHttpActionResult SaveTreatment(SaveTreatmentApiModel model)
        {
            var afflications = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AfflictionArea>>(model.Afflication);
            var observations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(model.Observations);
            var anamnesis = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(model.Anamnesis);

            var observationsAsTextArea = SetupAsTextArea(observations);
            var anamnesisAsTextArea = SetupAsTextArea(anamnesis);

            foreach (var afflictionArea in afflications)
            {
                afflictionArea.CreatedDate = DateTime.Now;
            }


            var treatment = new Treatment
            {
                AfflictionAreas = afflications,
                Anamnesis = anamnesisAsTextArea,
                Observations = observationsAsTextArea,
                CreatedDate = DateTime.Now,
                ChangedDate = DateTime.Now,
                CustomerId = model.CustomerId,
                UserId = 1
            };


            _treatmentService.SaveTreatment(treatment);
            


            return Ok();
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
        public string Observations { get; set; }
        public string Anamnesis { get; set; }
        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
    }
}
