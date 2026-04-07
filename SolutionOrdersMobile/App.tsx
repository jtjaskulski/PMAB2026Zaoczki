import React from 'react';
import { View, Text, StyleSheet, ScrollView, useColorScheme, StatusBar } from 'react-native';
import { SafeAreaProvider, SafeAreaView, useSafeAreaInsets } from 'react-native-safe-area-context';
import Greeting from './src/components/Greeting';
import Counter from './src/components/Counter';

function App(): React.JSX.Element {
  const isDarkMode = useColorScheme() === 'dark';
  return (
    <SafeAreaView>
      <StatusBar barStyle={isDarkMode ? 'light-content' : 'dark-content'} />
      <ScrollView>
        <Counter />
        <Text style={styles.title}>Hello Tomasz Litwiński!</Text>
        <Text style={styles.subtitle}>with TypeScript 🚀</Text>
        <Greeting name="Tomasz" age={24} isVip={true} />
        <Greeting name="Anna" age={30} />
        <Greeting name="Marek" isVip={true} />
      </ScrollView>
    </SafeAreaView> 
  );
}



const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#f5f5f5',
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#333',
  },
  subtitle: {
    fontSize: 16,
    color: '#666',
    marginTop: 8,
  },
});

export default App;