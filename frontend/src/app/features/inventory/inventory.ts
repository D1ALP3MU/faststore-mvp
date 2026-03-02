import { Component, OnInit } from '@angular/core';
import { InventoryService } from '../../services/inventory.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './inventory.html',
})
export class Inventory implements OnInit {

  products: any[] = [];
  filteredProducts: any[] = [];
  searchTerm: string = '';

  showModal = false;
  selectedProduct: any = null;
  quantity: number = 0;

  constructor(private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.inventoryService.getAll()
      .subscribe(data => {
        this.products = data;
        this.filteredProducts = data;
      });
  }

  filterProducts() {
    this.filteredProducts = this.products.filter(p =>
      p.nombre.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  openModal(product: any) {
    this.selectedProduct = product;
    this.quantity = 1;
    this.showModal = true;
  }

  createOrder() {
    const order = {
      productoId: this.selectedProduct.id,
      cantidad: this.quantity
    };

    this.inventoryService.createOrder(order)
      .subscribe({
        next: () => {
          alert('Orden creada correctamente ✅');
          this.showModal = false;
        },
        error: () => alert('Error al crear la orden ❌')
      });
  }
}
