using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Triage.DTOs;
using Triage.Models;

namespace Triage.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Patient, PatientDto>();
            Mapper.CreateMap<PatientRecord, PatientRecordDto>();
            Mapper.CreateMap<Doctor, DoctorDTO>();
            //.ForMember(c => c.Id, opt => opt.Ignore());


            //Dto to Domain
            Mapper.CreateMap<PatientDto, Patient>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<PatientRecordDto, PatientRecord>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<DoctorDTO, Doctor>()
                .ForMember(c => c.Id, opt => opt.Ignore());



        }
    }
}