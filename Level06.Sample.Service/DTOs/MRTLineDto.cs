using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service.DTOs
{
    public class MRTLineDto
    {
        /// <summary>
        ///     排序.
        /// </summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }

        /// <summary>
        ///     ID編號.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }

        /// <summary>
        ///     捷運線名稱.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     所在地區.
        /// </summary>
        /// <value>The area.</value>
        public string Area { get; set; }
    }
}