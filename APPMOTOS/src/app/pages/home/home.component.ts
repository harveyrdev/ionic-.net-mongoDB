import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';

import {
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonCard,
  IonButton,
  IonLabel,
  IonItem,
  IonIcon,
  IonRow,
  IonCol,
  IonFooter,
  IonList,
  IonBackButton,
  IonButtons,
  IonAvatar,
  IonText,
  IonThumbnail,
} from '@ionic/angular/standalone';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/service/product.service';
import { ModalPaymentComponent } from '../modal-payment/modal-payment.component';
IonHeader;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [ModalController],
  imports: [
    IonTitle,
    IonFooter,
    IonButton,
    IonLabel,
    IonItem,
    IonCard,
    IonHeader,
    IonToolbar,
    IonContent,
    IonList,
    CommonModule,
    IonBackButton,
    IonButtons,
    IonAvatar,
    IonThumbnail,
    IonText,
    IonRow,
    IonCol,
    IonIcon,
  ],
})
export class HomeComponent implements OnInit {
  productos: Product[] = [];
  carrito: Product[] = [];
  private _productService = inject(ProductService);
  private modalCtrl = inject(ModalController);
  total = 0;

  ngOnInit(): void {
    this.changeTot();
    this.cargarProductos();
  }
  async presentPaymentModal() {
    const modal = await this.modalCtrl.create({
      component: ModalPaymentComponent,
      cssClass: 'my-custom-modal-css', // Clase CSS personalizada para el modal
      presentingElement: await this.modalCtrl.getTop(),
      componentProps: {
        products: this.productos,
        total: this.total,
      },
    });
    await modal.present();
  }
  cargarProductos() {
    this._productService.getProducts().subscribe({
      next: (data: Product[]) => {
        console.log('Productos cargados:', data);
        this.productos = data;

        this.productos = data.map((product) => ({
          ...product, // Copia todas las propiedades existentes del producto
          quantity: 0, // Agrega el nuevo campo con valor predeterminado
        }));
      },
      error: (error) => {
        console.error('Error al cargar productos:', error);
      },
    });
  }

  addProduct(i: any) {
    this.productos[i].quantity++;
    this.changeTot();
  }

  minusProduct(i: any) {
    if (this.productos[i].quantity > 1) {
      this.productos[i].quantity--;
    } else {
      this.productos[i].quantity = 1;
    }

    this.changeTot();
  }

  changeTot() {
    this.total = 0;
    for (let i = 0; i < this.productos.length; i++) {
      this.total += this.productos[i].price * this.productos[i].quantity;
    }
  }
}
