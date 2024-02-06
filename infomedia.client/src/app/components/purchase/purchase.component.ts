import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../../services/purchase.service';
import { Purchase } from '../../models/purchase';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrl: './purchase.component.css'
})
export class PurchaseComponent implements OnInit {

  purchase = new Purchase();
  entityForm!: UntypedFormGroup;

  constructor(
    private purchaseService: PurchaseService,
    private fb: UntypedFormBuilder
  ) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.entityForm = this.fb.group({
      msisdn: [``],
      pin: [``]
    });
  }

  onSubmit(): void {
    this.bindInputs();
    this.insert();
  }

  bindInputs(): void {
    this.purchase.mSISDN = this.entityForm?.controls['msisdn'].value;
    this.purchase.pIN = this.entityForm?.controls['pin'].value;
  }

  insert(): void {
    console.log(this.purchase)
    this.purchaseService.purchaseUsingPhoneAndPin(this.purchase)
    .subscribe(
      () => {},
      (error) => {
        console.error(error);
      },
      () => {
      }
    );
  }
}
