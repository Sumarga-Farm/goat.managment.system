using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.Domain.MediaManagement
{
    public class PictureId : ValueObject
    {

        public Guid Value { get; set; }

        protected PictureId()
        {

        }
        protected PictureId(Guid pictureId)
        {
            Value = pictureId;
        }
        public static PictureId From(Guid pictureId)
        {
            return new PictureId(pictureId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static PictureId New()
        {
            return From(Guid.NewGuid());
        }


        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator string(PictureId pictureId) => pictureId.ToString();
    }
}
