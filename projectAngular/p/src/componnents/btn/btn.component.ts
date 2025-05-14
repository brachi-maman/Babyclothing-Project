import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-btn',
  standalone: true,
  imports: [],
  templateUrl: './btn.component.html',
  styleUrl: './btn.component.css'
})
export class BtnComponent {
  @Input() icon: string|undefined; 
  @Input() value: string|undefined; 
  @Input() id: string|undefined;  
  @Output() fromB = new EventEmitter();

  btn(){
    this.fromB.emit(this.id);
  }

}
