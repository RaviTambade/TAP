import { Component, OnInit, ViewChild, ElementRef, Input, Renderer2 } from '@angular/core';

@Component({
  selector: 'smiley',
  templateUrl: './smiley.component.html',
  styleUrls: ['./smiley.component.css']
})
export class SmileyComponent implements OnInit {


  ngOnInit() {
  }

  @ViewChild('canvas') canvasRef:ElementRef|undefined;
  private canvas: any;
  @Input('size') size: number|undefined;
  @Input('color') color: string|undefined;

  constructor(private el: ElementRef, private renderer: Renderer2) {   }

  ngAfterViewInit() {
      this.canvas = this.canvasRef?.nativeElement;
      this.canvas.width = this.size;
      this.canvas.height = this.size;
      this.draw();
  }
  draw() {
      if (this.canvas.getContext) {
          let canvas = this.canvas;
          if (canvas.getContext){
              var ctx = canvas.getContext('2d');
              ctx.beginPath();
              ctx.arc(canvas.width*.5,canvas.height*.5,canvas.width*.4,0,Math.PI*2,true); // Outer circle
              ctx.moveTo(canvas.width*0.80,canvas.height*.45);
              ctx.arc(canvas.width*.5, canvas.height*.45, canvas.width*.30, 0, Math.PI, false);  // Mouth (clockwise)
              ctx.moveTo(canvas.width*.35+canvas.width*0.05, canvas.height*.40);
              ctx.arc(canvas.width*.35,canvas.height*.40, canvas.width*0.05,0,Math.PI*2,true);  // Left eye
              ctx.moveTo(canvas.width*.65+canvas.width*0.05,canvas.height*.40);
              ctx.arc(canvas.width*.65,canvas.height*.40, canvas.width*0.05,0,Math.PI*2,true);  // Right eye
              ctx.strokeStyle = this.color;
              ctx.stroke();
          }
      }
  }
}
