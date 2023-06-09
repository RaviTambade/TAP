import { Component} from '@angular/core';
@Component({
  selector: 'number-pipe',
  template: `<div>
    <p>e (no formatting): {{e}}</p>
    <p>e (3.1-5): {{e | number:'3.1-5'}}</p>
    <p>pi (no formatting): {{pi}}</p>
    <p>pi (3.5-5): {{pi | number:'3.5-5'}}</p>
  </div>`
})
export class NumberPipeComponent {
  pi: number = 3.141592;
  e: number = 2.718281828459045;
}

