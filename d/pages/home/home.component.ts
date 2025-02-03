import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { IonHeader,IonToolbar,IonTitle,
  IonContent
  ,IonCard,IonCardHeader,IonCardTitle,IonCardSubtitle,IonCardContent,IonButton,IonLabel,
  IonItem,IonIcon,IonImg,IonGrid,IonRow,IonCol,IonFooter,IonInput,IonTextarea,IonList

 } from '@ionic/angular/standalone';
import { Product } from 'src/app/models/product';
import { OrderService } from 'src/app/service/order.service';
import { ProductService } from 'src/app/service/product.service';
IonHeader

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  imports:[
    IonCardHeader,
    IonTitle,
    IonCardTitle,

    IonCardContent,
    IonButton,
    IonLabel,
    IonItem,
    IonCard,
    IonHeader,
    IonToolbar,
    IonContent,IonList,CommonModule
  ]
})
export class HomeComponent  implements OnInit {
  productos: Product[] = [];
  carrito: Product[] = [];

  private _productService = inject(ProductService);
  private _orderService = inject(OrderService);
  

  constructor() { }

  cargarProductos() {
    this._productService.getProducts().subscribe(
      (data:any) => {

      
        this.productos = data;
      },
      (error) => {
        console.error('Error al cargar productos:', error);
      }
    );
  }

  agregarAlCarrito(producto: Product) {
    this.carrito.push(producto);
    console.log('Producto agregado al carrito:', producto);
  }

  realizarCompra() {
    this._orderService.crearOrden(this.carrito).subscribe(
      (response:any) => {
        console.log('Compra realizada:', response);
        this.carrito = []; // Vaciar el carrito
        alert('Compra realizada con éxito');
      },
      (error) => {
        console.error('Error al realizar la compra:', error);
        alert('Error al realizar la compra');
      }
    );
  }

  ngOnInit() {

    this.cargarProductos()
  }

}
