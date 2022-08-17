using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNode.ViewModel
{
    internal class IDGenerator
    {
        public static readonly IDGenerator ins = new IDGenerator();
        private long lastId_;

        private IDGenerator()
        {
            this.lastId_ = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public long Require()
        {
            var id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (id <= this.lastId_)
            {
                this.lastId_++;
            }
            this.lastId_ = id;
            return this.lastId_;
        }

        public string RequireStringGUID()
        {
            return this.Require().ToString();
        }
    }
}
