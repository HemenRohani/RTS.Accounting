import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Type } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'ng-modal-confirm',
  template: `
  <div class="modal-header">
    <h5 class="modal-title" id="modal-title">Delete Confirmation</h5>
    <button type="button" class="btn close" aria-label="Close button" aria-describedby="modal-title" (click)="modal.dismiss('Cross click')">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <div class="modal-body">
    <p>Are you sure you want to delete?</p>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-outline-secondary" (click)="modal.dismiss('cancel click')">CANCEL</button>
    <button type="button" ngbAutofocus class="btn btn-success" (click)="modal.close('Ok click')">OK</button>
  </div>
  `,
})
export class NgModalConfirm {
  constructor(public modal: NgbActiveModal) { }
}

const MODALS: { [name: string]: Type<any> } = {
  deleteModal: NgModalConfirm,
};

interface Document {
  id: number;
  type: string;
  number: string;
  externalInvoiceNumber: string;
  status: string;
  totalAmount: number;
}

@Component({
  selector: 'app-documents-list',
  templateUrl: './documents-list.component.html',
  styleUrl: './documents-list.component.css'
})
export class DocumentsListComponent implements OnInit {
  public documents: Document[] = [];

  constructor(private router: Router, private modalService: NgbModal,
    private toastr: ToastrService, private http: HttpClient) { }

  ngOnInit() {
    this.getDocuments();
  }

  getDocuments() {
    this.http.get<Document[]>('document/getDocuments').subscribe(
      (result) => {
        this.documents = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteDocumentConfirmation(document: any) {
    this.modalService.open(MODALS['deleteModal'],
      {
        ariaLabelledBy: 'modal-basic-title'
      }).result.then((result) => {
        this.deleteDocument(document);
      },
        (reason) => { });
  }

  deleteDocument(document: any) {
    this.http.post('document/removeDocument', { id: document.id }).subscribe((data: any) => {

      this.toastr.success("Succesfuly removed.");
      this.getDocuments();
    },
      (error: any) => { });
  }

  AddInvoiceDocument() {
    this.router.navigate(['AddInvoiceDocument']);
  }

  AddIndependentCreditNote() {
    this.router.navigate(['AddIndependentCreditNote']);
  }

  AddDependentCreditNote() {
    this.router.navigate(['AddDependentCreditNote']);
  }

}
