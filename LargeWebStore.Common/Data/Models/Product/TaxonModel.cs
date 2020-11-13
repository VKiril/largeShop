using LargeWebStore.Common.Domain.Data;
using System;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class TaxonModel : ModelBase
    {
        public override void SetId(Guid id)
        {
            Id = id;
            if (TreeRoot == Guid.Empty)
            {
                TreeRoot = id;
            }
        }

        //public new Guid Id
        //{
        //    get => Id;
        //    set
        //    {
        //        this.Id = value;
        //        if (TreeRoot == Guid.Empty)
        //        {
        //            TreeRoot = value;
        //        }
        //    }
        //}
        public Guid? TreeRoot { get; set; }
        public Guid? Parent { get; set; }
        public int TreeLevel { get; set; }
        public string Code { get; set; }
    }
}
