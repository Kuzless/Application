import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatImg',
})
export class FormatImgPipe implements PipeTransform {
  transform(imgName: string): string {
    if (!imgName) return '';
    return imgName.replace(/[\s-]/g, '');
  }
}
