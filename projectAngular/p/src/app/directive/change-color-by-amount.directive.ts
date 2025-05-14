import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appChangeColorByAmount]',
  standalone: true
})
export class ChangeColorByAmountDirective {

  constructor(private el: ElementRef) { }

  myElement: ElementRef | undefined
  @HostListener('click')
  color() {

    this.el.nativeElement.style.color = '#c53965'; 
   
  }

}
