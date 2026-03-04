import { Component, OnInit } from '@angular/core';
import { InventoryService } from '../../services/inventory.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Producto } from '../../models/producto.model';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './inventory.html',
})
export class Inventory implements OnInit {

  products: Producto[] = [];
  filteredProducts: Producto[] = [];
  searchTerm: string = '';

  showModal = false;
  selectedProduct: Producto | null = null;
  quantity: number = 0;

  constructor(private inventoryService: InventoryService, private cdRef: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.loadProducts();

    // setTimeout(() => {
    //   console.log('Productos cargados:', this.products);
    //   console.log('Productos filtrados:', this.filteredProducts);
    // }, 1000);
  }

  loadProducts() {
    console.log('Cargando productos...');
    this.inventoryService.getAll()
      .subscribe(data => {

        console.log('Respuesta API:', data);

        this.products = data;
        // Mostrar todos los productos inicialmente
        this.filteredProducts = data;

        // Forzar detección de cambios para actualizar la vista
        this.cdRef.detectChanges();
      });
  }

  filterProducts() {
    // Si el término de búsqueda está vacío, mostrar todos los productos
    if (!this.searchTerm) {
      this.filteredProducts = this.products;
      return;
    }

    this.filteredProducts = this.products.filter(p =>
      p.nombre.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  openModal(product: Producto) {
    this.selectedProduct = product;
    this.quantity = 1;
    this.showModal = true;
  }

  createOrder() {

    if (!this.quantity || this.quantity <= 0) {
      alert('La cantidad debe ser mayor a cero');
      return;
    }

    const order = {
      productoId: this.selectedProduct!.id,
      cantidad: this.quantity
    };

    this.inventoryService.createOrder(order)
      .subscribe({
        next: () => {

          alert('Orden creada correctamente ✅');

          // cerrar modal
          this.showModal = false;

          // limpiar datos
          this.selectedProduct = null;
          this.quantity = 0;

          // Recargar inventario para actualizar la tabla
          this.loadProducts();

          // Forzar detección de cambios para actualizar la vista
          this.cdRef.detectChanges();
        },
        error: (err) => {
          console.error(err);
          alert('Error al crear la orden ❌');
        }
      });
    }
    // trackById(index: number, item: Producto): number {
    //   return item.id;
    // }
}
