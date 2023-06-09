import { Component} from '@angular/core';

@Component({
  selector: 'json-pipe',
  template: `<div>
                <p>Without JSON pipe:</p>
                <pre>{{object}}</pre>


                
                <p>With JSON pipe:</p>
                <pre>{{object | json}}</pre>
            </div>`
})
export class JsonPipeComponent {
  object: Object = {name: 'Gerbera',
                    category: 'Flower',
                    greenhouses: {name: 'Lakshya',
                    montlyRevenue: [34, 45,43, 74, 55]}};
}