import { Component, Input } from '@angular/core';
import { CoworkingPageDataInterface } from '../../interfaces/coworking-page/coworking-page-data.interface';
import { FormatImgPipe } from '../../pipes/format-img.pipe';
import { CommonModule, LowerCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { WorkspaceTypes } from '../../enums/workspace-types.enum';
import { RoomTypeWithRoomsInterface } from '../../interfaces/room-type-with-rooms.interface';
import { RoomTypeInterface } from '../../interfaces/base-dtos/room-type.interface';

@Component({
  selector: 'app-coworking-card',
  imports: [FormatImgPipe, LowerCasePipe, RouterLink, CommonModule],
  templateUrl: './coworking-card.component.html',
  styleUrl: './coworking-card.component.css',
})
export class CoworkingCardComponent {
  @Input() coworking?: CoworkingPageDataInterface;

  readonly WorkspaceTypes = WorkspaceTypes;

  readonly iconsUrl: string = 'booking/coworking-element/icons/';
  readonly imagesUrl: string = 'booking/coworking-element/images/';
  readonly iconsFormat: string = '.svg';
  readonly imagesFormat: string = '.png';
  readonly imageName: string = '1';

  readonly locationIconName: string = 'location';
  readonly workspaceIconName: string = 'workspace';

  get getWorkspaceRoute() {
    return `${this.coworking?.coworking.id}`;
  }

  getRoomType(typeName: WorkspaceTypes): RoomTypeWithRoomsInterface {
    var roomtype = this.coworking?.roomTypesWithRooms.find((rt) => {
      return rt.roomType.type === typeName;
    });
    if (!roomtype) {
      roomtype = {
        roomType: {} as RoomTypeInterface,
        rooms: [],
      } as RoomTypeWithRoomsInterface;
    }
    return roomtype;
  }
}
