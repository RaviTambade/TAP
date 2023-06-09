import { Component, OnInit, ViewChild, Input, ElementRef, Renderer2 } from '@angular/core';
import { Unsubscribable } from 'rxjs';

@Component({
  selector: 'line',
  templateUrl: './line.component.html',
  styleUrls: ['./line.component.css']
})
export class LineComponent implements OnInit {

  ngOnInit() {  }

  @ViewChild('canvas') canvasRef:ElementRef|undefined;

  private canvas: any;

  @Input('size') size: number|undefined;
  @Input('color') color: string|undefined;
  @Input('x1') x1: number|undefined;
  @Input('y1') y1: number|undefined;
  @Input('x2') x2: number|undefined;
  @Input('y2') y2: number|undefined;

  constructor(private el: ElementRef, private renderer: Renderer2) {    }


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
              ctx.moveTo(this.x1,this.y1);
              ctx.lineTo(this.x2,this.y2);
              ctx.strokeStyle = this.color;   //pen
              ctx.stroke();
          }
      }
  }
}
