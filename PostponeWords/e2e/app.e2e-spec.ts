import { PostponeWordsPage } from './app.po';

describe('postpone-words App', () => {
  let page: PostponeWordsPage;

  beforeEach(() => {
    page = new PostponeWordsPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
