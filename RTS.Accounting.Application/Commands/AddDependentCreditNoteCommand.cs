using MediatR;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;
using RTS.Accounting.Domain.Interfaces;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Commands
{
    public record AddDependentCreditNoteCommand(string Number, string ExternalInvoiceNumber,
        DocumentStatus Status, long TotalAmount, int ParentInvoiceId) : IRequest<Unit>;

    public class AddDependentCreditNoteCommandHandler(IUnitOfWork unitOfWork, IDependentCreditNoteRepository dependentCreditNoteRepository) 
        : IRequestHandler<AddDependentCreditNoteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDependentCreditNoteRepository _dependentCreditNoteRepository = dependentCreditNoteRepository;
        public async Task<Unit> Handle(AddDependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var dependentCreditNote = DependentCreditNote.Create(request.Number, request.ExternalInvoiceNumber, request.Status,
                request.TotalAmount, request.ParentInvoiceId);

            _dependentCreditNoteRepository.Add(dependentCreditNote);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
