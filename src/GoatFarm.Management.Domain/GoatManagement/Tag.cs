using GoatFarm.Management.Domain.SharedKernel;
using GoatFarm.Management.Domain.TenantManagement;

namespace GoatFarm.Management.Domain.GoatManagement
{
    public class Tag : BaseEntity<TagId>, IAggregateRoot
    {
        public TagNumber TagNumber { get; set; }
        public bool IsFreeToUse { get; private set; }
        public FarmId FarmId { get; private set; }
        protected Tag()
        {

        }

        public static Tag[] BuildInitial99TagsForSumargaFarm()
        {
            string format = "D3";//3 digits
            IList<Tag> tags = new List<Tag>();
            for (int tagNumber = 1; tagNumber < 100; tagNumber++)
            {
                Tag tag = SumargaFarmTag(TagNumber.From(tagNumber.ToString(format)));
                tags.Add(tag);
            }
            return tags.ToArray();
        }

        private static Tag SumargaFarmTag(TagNumber tagNumber)
        {
            return new Tag
            {
                Id = TagId.NewId(),
                TagNumber = tagNumber,
                FarmId = FarmId.SumargaGoatFarmId,
                IsFreeToUse = true
            };
        }
    }
}