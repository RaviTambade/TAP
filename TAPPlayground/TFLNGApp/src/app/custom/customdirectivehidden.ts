import { Directive, ElementRef, Input, Renderer2 } from '@angular/core';
//Custom attribute directive/ element directive



//step 1: Write custom class 
//step 2: decorate using @Directive  decorator
//step 3: inject ElementRef and Renderer in constructor
//step 4: Write the logic for ngOnit to change visible appearance of element
//step 5:delcalre Directiveclass in module
//step 6:export Directie class from module


@Directive({ selector: '[myHidden]' })
export class HiddenDirective {
    constructor(public el: ElementRef, public renderer: Renderer2) {}
    @Input() myHidden: boolean|undefined;
    ngOnInit(){
        if(this.myHidden) {
            this.renderer.setAttribute(this.el.nativeElement, 'display', 'none');
        }
    }
}
 
 /*
@Directive({ selector: '[myHidden]' })
export class HiddenDirective {
    constructor(el: ElementRef, renderer: Renderer) {
     // Use renderer to render the element with styles
       renderer.setElementStyle(el.nativeElement, 'display', 'none');

    }
}
 */