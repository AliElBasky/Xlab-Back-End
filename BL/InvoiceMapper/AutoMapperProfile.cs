using AutoMapper;
using DAL;

namespace BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Invoice?, InvoiceDTO>();
        CreateMap<InvoiceDTO, Invoice>();

        CreateMap<InvoiceDetails?, InDetailsDTO>();
        CreateMap<InDetailsDTO, InvoiceDetails>();
    }
}
