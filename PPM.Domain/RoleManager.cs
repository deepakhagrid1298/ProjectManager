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

        public ActionResult AddRole(Role role)
        {
            ActionResult result = new ActionResult() { IsSuccess = true };
            try
            {
                if (rolelist.Count > 0)
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
            if (rolelist.Count > 0)
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
        public ActionResult IsValidRole(Role role)
        {
            ActionResult action = new ActionResult() { IsSuccess = true };
            try
            {
                if (rolelist.Exists(r => r.RoleName == role.RoleName))
                {
                    action.IsSuccess = true;
                }
                else
                {
                    action.IsSuccess = false;
                    action.Status = "Role is not in the Role List" + role.RoleName;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                action.IsSuccess = false;
            }
            return action;
        }

    }
}