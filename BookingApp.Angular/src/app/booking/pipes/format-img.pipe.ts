import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatImg',
})

// removes spaces and '-' from string
export class FormatImgPipe implements PipeTransform {
  transform(imgName: string): string {
    if (!imgName) return '';
    return imgName.replace(/[\s-]/g, '');
  }
}
