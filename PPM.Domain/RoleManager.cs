using PPM.Model;
using PPM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM.Domain
{
    public class RoleManager
    {
        private static List<Role> rolelist = new List<Role>();
        //public RoleManager()
        //{
        //    _roleList = new List<Role>();
        //}

        public ActionResult AddRole(Role role)
        {
            ActionResult result = new ActionResult() { IsSuccess = true };
            try
            {
                if (rolelist.Count() > 0)
                {
                    if (rolelist.Exists(r => r.RoleId == role.RoleId))
                    {
                        result.IsSuccess = false;
                        result.Status = "Validation Failed";
                    }
                    else
                    {
                        rolelist.Add(role);
                        result.Status = "Role Added";
                    }
                }
                else
                {
                    rolelist.Add(role);
                    result.Status = "New Role Added";
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Status = "Exception Occured : " + e.ToString();
            }
            return result;

        }

        public DataResult<Role> GetRole()
        {
            DataResult<Role> roleResult = new DataResult<Role>() { IsSuccess = true };
            if (rolelist.Count() > 0)
            {
                roleResult.results = rolelist;
            }
            else
            {
                roleResult.IsSuccess = false;
                roleResult.Status = "No Role in list";
            }
            return roleResult;
        }

    }
}