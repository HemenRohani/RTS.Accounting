using MediatR;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;
using RTS.Accounting.Domain.Interfaces;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Commands
{
    public record AddInvoiceDocumentCommand(string Number, string ExternalInvoiceNumber, DocumentStatus Status, long TotalAmount) : IRequest<Unit>;

    public class AddInvoiceDocumentCommandHandler(IUnitOfWork unitOfWork, IInvoiceDocumentRepository invoiceDocumentRepository) 
        : IRequestHandler<AddInvoiceDocumentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IInvoiceDocumentRepository _invoiceDocumentRepository = invoiceDocumentRepository;
        public async Task<Unit> Handle(AddInvoiceDocumentCommand request, CancellationToken cancellationToken)
        {
            var invoiceDocument = InvoiceDocument.Create(request.Number, request.ExternalInvoiceNumber, request.Status, request.TotalAmount);
            _invoiceDocumentRepository.Add(invoiceDocument);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
