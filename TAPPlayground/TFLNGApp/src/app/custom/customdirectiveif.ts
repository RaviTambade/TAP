import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';




//step 1: Write custom class 
//step 2: decorate using @Directive  decorator
//step 3: inject templateRef and ViewContainerRef in constructor
//step 4: Write the logic for ngOnit to change visible appearance of element
//step 5:delcalre Directiveclass in module
//step 6:export Directie class from module

@Directive({ selector: '[myIf]' })
export class IfDirective {
  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef
    ) { }

  @Input() set myIf(shouldAdd: boolean) {
    if (shouldAdd) {
      // If condition is true add template to DOM
      this.viewContainer.createEmbeddedView(this.templateRef);
    } else {
     // Else remove template from DOM
      this.viewContainer.clear();
    }
  }
}