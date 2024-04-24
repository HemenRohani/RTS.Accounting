import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, numberAttribute } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-dependent-credit-note',
  templateUrl: './add-dependent-credit-note.component.html',
  styleUrl: './add-dependent-credit-note.component.css'
})

export class AddDependentCreditNoteComponent implements OnInit {
  public documents: Document[] = [];
  addDependentCreditNoteForm: dependentCreditNoteForm = new dependentCreditNoteForm();

  @ViewChild("dependentCreditNoteForm")
  dependentCreditNoteForm!: NgForm;

  isSubmitted: boolean = false;

  constructor(private router: Router, private http: HttpClient, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getInvoiceDocuments();
  }

  getInvoiceDocuments() {
    this.http.get<Document[]>('document/getDocuments?Type=0').subscribe(
      (result) => {
        this.documents = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  AddDependentCreditNote(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.addDependentCreditNoteForm.ParentInvoiceId = Number.parseInt(this.addDependentCreditNoteForm.ParentInvoiceId.toString());
      this.addDependentCreditNoteForm.Status = Number.parseInt(this.addDependentCreditNoteForm.Status.toString());
      this.http.post('/document/addDependentCreditNote', this.addDependentCreditNoteForm).subscribe(async data => {
        this.toastr.success("Succesfuly Added.");
        setTimeout(() => {
          this.router.navigate(['/Home']);
        }, 500);
      },
        async error => {
          this.toastr.error("Error in adding.");
        });
    }
  }

}

interface Document {
  id: number;
  type: string;
  number: string;
  externalInvoiceNumber: string;
  status: string;
  totalAmount: number;
}

export class dependentCreditNoteForm {
  Number: string = "";
  ExternalInvoiceNumber: string = "";
  Status: number = 0;
  TotalAmount: number = 0;
  ParentInvoiceId: number = 0;
}
