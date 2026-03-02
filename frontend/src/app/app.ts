import { Component, signal } from '@angular/core';
//import { RouterOutlet } from '@angular/router';
import { Inventory } from './features/inventory/inventory';

@Component({
  selector: 'app-root',
  imports: [Inventory],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App {
  protected readonly title = signal('frontend');
}
