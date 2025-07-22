using System.Collections.Generic;

namespace NativeAppCleanup
{
    public class FeatureNode
    {
        public string Category { get; set; }
        public FeatureBase Feature { get; set; }
        public List<FeatureNode> Children { get; set; } = new List<FeatureNode>();

        public FeatureNode(string category)
        {
            Category = category;
        }

        public FeatureNode(FeatureBase feature)
        {
            Feature = feature;
        }

        public override string ToString()
        {
            return Feature?.ID() ?? Category;
        }
    }
}