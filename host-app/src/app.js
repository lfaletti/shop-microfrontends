import { LitElement, html, css } from 'lit';

export class HostApp extends LitElement {
  static styles = css`
    .container {
      padding: 20px;
      min-height: 100vh;
      display: flex;
      flex-direction: column;
    }

    .microfrontend-container {
      flex: 1;
      margin: 24px;
      padding: 32px;
      border-radius: 8px;
      background: #ffffff;
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
      height: 80vh;
      overflow: auto;
    }

    iframe {
      width: 100%;
      height: 100%;
      border: none;
      min-height: 600px;
    }

    nav {
      display: flex;
      gap: 16px;
      padding: 16px;
      background: #f5f5f5;
    }
  `;

  constructor() {
    super();
    const eventQueue = {};
    window.eventBus = {
      eventQueue,
      dispatch: (event, data) => {
        console.log('Event dispatched:', event, data);
        window.dispatchEvent(new CustomEvent(event, { detail: data }));
        // Store event in queue
        if (!eventQueue[event]) {
          eventQueue[event] = [];
        }
        eventQueue[event].push(data);
      },
      subscribe: (event, callback) => {
        window.addEventListener(event, (e) => callback(e.detail));
        // Replay queued events for this subscription
        if (eventQueue[event]) {
          eventQueue[event].forEach(data => callback(data));
        }
      }
    };
    console.log('EventBus initialized:', window.eventBus);
  }

  firstUpdated() {
    this.setupRouting();
  }

  setupRouting() {
    this.shadowRoot.addEventListener('click', (e) => {
      const link = e.target.closest('a');
      if (link) {
        e.preventDefault();
        const path = link.getAttribute('href');
        this.loadMicrofrontend(path);
        history.pushState({}, '', path);
      }
    });
  }

  loadMicrofrontend(path) {
    const container = this.shadowRoot.querySelector('.microfrontend-container');
    container.innerHTML = `<iframe src="${path}" style="width: 100%; height: 100%; border: none;"></iframe>`;
  }

  render() {
    return html`
      <div class="container">
        <nav>
          <a href="/products-app/">Products</a>
          <a href="/cart-app/">Cart</a>
        </nav>
        <div class="microfrontend-container"></div>
      </div>
    `;
  }
}

customElements.define('host-app', HostApp);