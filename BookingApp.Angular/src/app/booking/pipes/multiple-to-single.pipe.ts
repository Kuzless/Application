import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'multipleToSingle',
})

// removes 's' from string i.e. transforms 'items' into 'item'
export class MultipleToSinglePipe implements PipeTransform {
  transform(value: string): string {
    if (value.endsWith('s')) {
      return value.slice(0, -1);
    }
    return value;
  }
}
