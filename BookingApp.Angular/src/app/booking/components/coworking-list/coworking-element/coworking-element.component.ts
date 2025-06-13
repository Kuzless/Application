import { Component, Input } from '@angular/core';
import { CoworkingInfoResponseInterface } from '../interfaces/coworking-info-response.interface';
import { FormatImgPipe } from '../../../shared/pipes/format-img.pipe';
import { CommonModule, LowerCasePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { WorkspaceTypes } from '../../../shared/enums/workspace-types.enum';
import { RoomTypeWithRoomsInterface } from '../interfaces/room-type-with-rooms.interface';
import { RoomTypeInterface } from '../../../shared/interfaces/dto/room-type.interface';

@Component({
  selector: 'app-coworking-element',
  imports: [FormatImgPipe, LowerCasePipe, RouterLink, CommonModule],
  templateUrl: './coworking-element.component.html',
  styleUrl: './coworking-element.component.css',
})
export class CoworkingElementComponent {
  @Input() coworking?: CoworkingInfoResponseInterface;

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
