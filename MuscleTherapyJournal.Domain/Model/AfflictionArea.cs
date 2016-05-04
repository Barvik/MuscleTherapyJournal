using System;

namespace MuscleTherapyJournal.Domain.Model
{
    public class AfflictionArea
    {
        public int AfflictionAreaId { get; set; }
        public double MouseXPosition { get; set; }
        public double MouseYPosition { get; set; }
        public int CrossSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
        public bool IsPersisted { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "AfflicationArea: [AfflictionAreaId: {0}, MouseXPosition: {1}, MouseYPosition: {2}, CrossSize: {3}" +
                    "CreatedDate: {4}, TreatmentId: {5}]", AfflictionAreaId, MouseXPosition, MouseYPosition, CrossSize,
                    CreatedDate, TreatmentId);
        }
    }
}
