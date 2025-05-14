import { Component } from '@angular/core';

@Component({
  selector: 'app-size',
  standalone: true,
  imports: [],
  templateUrl: './size.component.html',
  styleUrl: './size.component.css'
})
export class SizeComponent {
  // navigateToSizeGuide() {
  //   window.open('https://babybasic.co.il/size-guide/?srsltid=AfmBOopWr4w5H3i5Stwe3PhsygPKAyasErI9gLk06l8trTezjagy4qiY', '_blank');
  // }
  sizes = [
    { age: '0-3 חודשים', weight: '2.5-5 ק"ג', height: '50-60 ס"מ', size: '0-3M' },
    { age: '3-6 חודשים', weight: '5-7 ק"ג', height: '60-65 ס"מ', size: '3-6M' },
    { age: '6-9 חודשים', weight: '7-9 ק"ג', height: '65-70 ס"מ', size: '6-9M' },
    { age: '9-12 חודשים', weight: '9-11 ק"ג', height: '70-75 ס"מ', size: '9-12M' },
    { age: '12-18 חודשים', weight: '11-13 ק"ג', height: '75-80 ס"מ', size: '12-18M' },
    { age: '18-24 חודשים', weight: '13-15 ק"ג', height: '80-85 ס"מ', size: '18-24M' },
  ];


}