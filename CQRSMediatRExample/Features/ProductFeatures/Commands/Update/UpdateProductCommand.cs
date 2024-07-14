using CQRSMediatRExample.Features.ProductFeatures.Dtos;
using MediatR;

namespace CQRSMediatRExample.Features.ProductFeatures.Commands.Update;

public record UpdateProductCommand(Guid Id, UpdateProductDto UpdateProductDto) : IRequest<ProductDto>;
