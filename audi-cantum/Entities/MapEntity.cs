using System.Drawing;

namespace new_ga_e.Entities
{
    public class MapEntity
    {
        public PointF position;
        public Size size;

        public MapEntity(PointF pos, Size size) 
        { 
            this.position = pos;
            this.size = size;
        }
    }
}
