using System.Collections.Generic;
using ToReadList.Models;

namespace ToReadList.Models
{
public class ManageUsersViewModel
{
public ApplicationUser[] Administrators { get; set; }
public ApplicationUser[] Everyone { get; set;}
}
}