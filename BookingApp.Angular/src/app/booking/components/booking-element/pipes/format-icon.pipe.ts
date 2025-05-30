import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatIcon',
})
export class FormatIconPipe implements PipeTransform {
  transform(iconName: string): string {
    if (!iconName) return '';
    return iconName.replace(/[\s-]/g, '');
  }
}
