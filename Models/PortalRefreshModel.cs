using OpenNos.Domain;

namespace WebAPI.Models
{
    public class PortalRefreshModel
    {
        public short MapId { get; set; }

        public MapInstanceType mapInstanceType { get; set; }
    }
}
