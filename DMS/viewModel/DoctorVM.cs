using AutoMapper;
using DMS.Models;

namespace DMS.viewModel;
[AutoMap(typeof(Doctor),ReverseMap =true)]

public class DoctorVM
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
