import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import {
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonButton,
  IonLabel,
  IonItem,
  IonIcon,
  IonGrid,
  IonRow,
  IonCol,
  IonInput,
  IonButtons,
  NavParams,
} from '@ionic/angular/standalone';
import { Order } from 'src/app/models/order';
import { Product } from 'src/app/models/product';
import { OrderService } from 'src/app/service/order.service';
@Component({
  imports: [
    IonHeader,
    IonToolbar,
    IonTitle,
    IonContent,
    IonButton,
    IonLabel,
    IonItem,
    IonIcon,
    IonGrid,
    IonRow,
    IonCol,
    IonInput,
    IonButtons,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  selector: 'app-modal-payment',
  templateUrl: './modal-payment.component.html',
  styleUrls: ['./modal-payment.component.scss'],
  providers: [ModalController],
})
export class ModalPaymentComponent implements OnInit {
  cardNumber: string = '';
  expirationDate: string = '';
  custumer: string = '';
  cvv: string = '';
  shippingAddress: string = '';
  @Input() products: Product[] = [];
  order: Order = {
    totalAmount: 0,
    orderItems: [],
    customerName: '',
  };
  @Input() total: number = 0;
  private modalCtrl = inject(ModalController);
  private _orderService = inject(OrderService);

  dismiss() {
    this.modalCtrl.dismiss();
  }
  constructor() {}

  ngOnInit() {}

  onSubmit() {
    this.order.orderItems = this.products;
    this.order.orderItems = this.order.orderItems.filter(
      (product: Product) => product.quantity > 0
    );

    this.order.totalAmount = this.total;
    this.order.customerName = this.custumer;

    this._orderService.crearOrden(this.order).subscribe({
      next: (data) => {
        alert('Compra efectuada correctamente');
        this.modalCtrl.dismiss();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
