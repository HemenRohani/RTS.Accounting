using MediatR;
using RTS.Accounting.Domain.Entities;
using RTS.Accounting.Domain.Enums;
using RTS.Accounting.Domain.Interfaces;
using RTS.Accounting.Domain.Repositories;

namespace RTS.Accounting.Application.Commands
{
    public record AddIndependentCreditNoteCommand(string Number, string ExternalInvoiceNumber, DocumentStatus Status, long TotalAmount) : IRequest<Unit>;

    public class AddIndependentCreditNoteCommandHandler(IUnitOfWork unitOfWork, IIndependentCreditNoteRepository independentCreditNoteRepository) 
        : IRequestHandler<AddIndependentCreditNoteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IIndependentCreditNoteRepository _independentCreditNoteRepository = independentCreditNoteRepository;
        public async Task<Unit> Handle(AddIndependentCreditNoteCommand request, CancellationToken cancellationToken)
        {
            var independentCreditNote = IndependentCreditNote.Create(request.Number, request.ExternalInvoiceNumber, request.Status, request.TotalAmount);
            _independentCreditNoteRepository.Add(independentCreditNote);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
