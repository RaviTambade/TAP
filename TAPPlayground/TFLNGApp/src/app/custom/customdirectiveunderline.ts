import { Directive, HostListener, ElementRef, Renderer2 } from '@angular/core';

@Directive({
    selector: '[tflUnderline]'
})
export class UnderlineDirective {
    constructor(private el: ElementRef,private renderer: Renderer2){}
    
    @HostListener('mouseenter') onMouseEnter() { this.hover(true); }
    @HostListener('mouseleave') onMouseLeave() { this.hover(false); }

    hover(shouldUnderline: boolean){
        if(shouldUnderline){  
        this.renderer.setAttribute(this.el.nativeElement, 'text-decoration', 'underline');
        } else {         
        this.renderer.setAttribute(this.el.nativeElement, 'text-decoration', 'none');
        }
    }
}