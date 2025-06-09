import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'multipleToSingle',
})
export class MultipleToSinglePipe implements PipeTransform {
  transform(value: string): string {
    if (value.endsWith('s')) {
      return value.slice(0, -1);
    }
    return value;
  }
}
