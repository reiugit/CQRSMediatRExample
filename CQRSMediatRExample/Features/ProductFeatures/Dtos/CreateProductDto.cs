using CQRSMediatRExample.Domain;

namespace CQRSMediatRExample.Features.ProductFeatures.Dtos;

public record CreateProductDto(string Name)
{
    public Product ToProduct()
        => new() { Name = Name };
}
