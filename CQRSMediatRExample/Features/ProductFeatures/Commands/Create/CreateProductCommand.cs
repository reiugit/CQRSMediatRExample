using MediatR;
using CQRSMediatRExample.Features.ProductFeatures.Dtos;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Create;

public record CreateProductCommand(CreateProductDto CreateProductDto) : IRequest<ProductDto>;
