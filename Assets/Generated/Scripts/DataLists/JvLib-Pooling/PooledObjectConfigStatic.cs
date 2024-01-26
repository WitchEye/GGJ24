using JvLib.Data;

namespace JvLib.Pooling.Data.Objects
{
    public partial class PooledObjectConfig
    {
        private static JvLib.Pooling.Data.Objects.PooledObjectConfigs values;
        private static JvLib.Pooling.Data.Objects.PooledObjectConfig ammunition;

        public static JvLib.Pooling.Data.Objects.PooledObjectConfigs Values
        {
            get
            {
                if (values == null)
                    values = (JvLib.Pooling.Data.Objects.PooledObjectConfigs)DataRegistry.GetList("59e5ce10c9334a84999ee081725105f3");
                return values;
            }
        }

        public static JvLib.Pooling.Data.Objects.PooledObjectConfig Ammunition
        {
            get
            {
                if (ammunition == null && Values != null)
                    ammunition = (JvLib.Pooling.Data.Objects.PooledObjectConfig)Values.GetEntry("8d6c0d67201d0d14db216809c26e5599");
                return ammunition;
            }
        }

    }
}

