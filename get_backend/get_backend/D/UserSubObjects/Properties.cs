
/*
 * Properties is used to store bool related data regarding user information
 */

using System.Reflection;
using get_backend.D.PrimitiveObjects;

namespace get_backend.D.UserSubObjects
{
    internal sealed class Properties
    {
        internal readonly Property CanDriveCar;
        internal readonly Property AccessToCar;
        internal readonly Property UserCanMove;
        internal readonly Property FullTimeJob;
        internal readonly Property PartTimeJob;
        internal readonly Property WillCommute;
        internal readonly Property PublishUser;

        internal Properties()
        {
            PublishUser = new Property();
            WillCommute = new Property();
            PartTimeJob = new Property();
            FullTimeJob = new Property();
            UserCanMove = new Property();
            AccessToCar = new Property();
            CanDriveCar = new Property();
        }        
        
        internal Properties(Properties p)
        {
            PublishUser = new Property(p.PublishUser.Value);
            WillCommute = new Property(p.WillCommute.Value);
            PartTimeJob = new Property(p.PartTimeJob.Value);
            FullTimeJob = new Property(p.FullTimeJob.Value);
            UserCanMove = new Property(p.UserCanMove.Value);
            AccessToCar = new Property(p.AccessToCar.Value);
            CanDriveCar = new Property(p.CanDriveCar.Value);
        }
    }
}
