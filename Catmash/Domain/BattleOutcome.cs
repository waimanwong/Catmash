using System;

namespace Catmash.Domain
{
    public class BattleOutcome
    {
        /// <summary>
        /// internal id
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Battle occurrence date
        /// </summary>
        public DateTimeOffset Date { get; private set; }
        public string SelectedImageId { get; private set; }
        public string UnselectedImageId { get; private set; }

        public BattleOutcome(string selectedImageId, string unselectedImageId)
        {
            Date = DateTimeOffset.UtcNow;
            SelectedImageId = selectedImageId;
            UnselectedImageId = unselectedImageId;
        }

        /// <summary>
        /// For EF Core
        /// </summary>
        private BattleOutcome() {  }
    }
}
