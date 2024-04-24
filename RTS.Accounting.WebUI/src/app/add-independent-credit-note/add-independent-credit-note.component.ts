import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-independent-credit-note',
  templateUrl: './add-independent-credit-note.component.html',
  styleUrl: './add-independent-credit-note.component.css'
})

export class AddIndependentCreditNoteComponent implements OnInit {
  addIndependentCreditNoteForm: independentCreditNoteForm = new independentCreditNoteForm();

  @ViewChild("independentCreditNoteForm")
  independentCreditNoteForm!: NgForm;

  isSubmitted: boolean = false;

  constructor(private router: Router, private http: HttpClient, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  AddIndependentCreditNote(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.addIndependentCreditNoteForm.Status = Number.parseInt(this.addIndependentCreditNoteForm.Status.toString());
      this.http.post('/document/addIndependentCreditNote', this.addIndependentCreditNoteForm).subscribe(async data => {
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

export class independentCreditNoteForm {
  Number: string = "";
  ExternalInvoiceNumber: string = "";
  Status: number = 0;
  TotalAmount: number = 0;
}
