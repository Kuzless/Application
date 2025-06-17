import { applicationConfig, StoryObj } from '@storybook/angular';
import { CoworkingCardComponent } from '../../../app/booking/components/coworking-card/coworking-card.component';
import { mockCoworkingCard } from './coworking-card.mocks';
import { provideRouter } from '@angular/router';

export default {
  title: 'CoworkingCard',
  component: CoworkingCardComponent,
  decorators: [
    applicationConfig({
      providers: [provideRouter([])],
    }),
  ],
};

type Story = StoryObj<CoworkingCardComponent>;

export const CoworkingCardMock: Story = {
  args: {
    coworking: mockCoworkingCard,
  },
};
