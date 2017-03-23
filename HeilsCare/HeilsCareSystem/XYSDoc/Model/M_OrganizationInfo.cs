using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_OrganizationInfo
    {
        #region Primitive Properties

        public virtual string Address
        {
            get;
            set;
        }
        public virtual Nullable<int> AreaID
        {
            get;
            set;
        }

        public virtual string BannerFile
        {
            get;
            set;
        }

        public virtual string Contact
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual int DispOrder
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string FaxNO
        {
            get;
            set;
        }

        public virtual Nullable<sbyte> GroupType
        {
            get;
            set;
        }

        public virtual sbyte Invalid
        {
            get;
            set;
        }

        public virtual string Latitude
        {
            get;
            set;
        }

        public virtual string Logofile
        {
            get;
            set;
        }

        public virtual string Longitude
        {
            get;
            set;
        }

        public virtual string MembersSiteLogo
        {
            get;
            set;
        }

        public virtual string OrgCode
        {
            get;
            set;
        }

        public virtual string OrgFullName
        {
            get;
            set;
        }

        public virtual int OrgID
        {
            get;
            set;
        }

        public virtual sbyte OrgKind
        {
            get;
            set;
        }

        public virtual Nullable<sbyte> OrgLevel
        {
            get;
            set;
        }

        public virtual string OrgName
        {
            get;
            set;
        }

        public virtual int OrgOrder
        {
            get;
            set;
        }

        public virtual string OrgPath
        {
            get;
            set;
        }

        public virtual sbyte OrgType
        {
            get;
            set;
        }

        public virtual int ParentOrgID
        {
            get;
            set;
        }

        public virtual string Phone
        {
            get;
            set;
        }

        public virtual int UnitId
        {
            get;
            set;
        }

        public virtual sbyte IsInheritBaseInfo
        {
            get;
            set;
        }

        public sbyte ServeUnitFlag { get; set; }


        public virtual sbyte IsPublic
        {
            get;
            set;
        }

        public virtual sbyte IsAllowReserve
        {
            get;
            set;
        }
        /// <summary>
        /// [5.0.12]是否接受专业咨询：0-否，1-是
        /// </summary>
        public virtual sbyte IsAllowNetDiagnose
        {
            get;
            set;
        }
        /// <summary>
        /// [5.0.12]是否接受免费咨询：0-否，1-是
        /// </summary>
        public virtual sbyte IsAllowConsuit
        {
            get;
            set;
        }
        #endregion
    }
}
