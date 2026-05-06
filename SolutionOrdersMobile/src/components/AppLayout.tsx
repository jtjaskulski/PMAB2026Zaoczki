import React from 'react';
import { View, Text, StyleSheet, Image } from 'react-native';

type Props = {
  children: React.ReactNode;
};

export default function AppLayout({ children }: Props) {
  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <Image
          source={require('../../assets/logo3.png')}
          style={styles.logo}
        />
        <Text style={styles.appName}>Bike-Rental</Text>
        <Text style={styles.panelText}>Panel pracownika</Text>
      </View>

      <View style={styles.content}>{children}</View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#0F172A',
  },
  header: {
    alignItems: 'center',
    paddingTop: 12,
    paddingBottom: 18,
    borderBottomWidth: 1,
    borderBottomColor: '#1E293B',
  },
  logo: {
    width: 120,
    height: 70,
    resizeMode: 'contain',
  },
  appName: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#E5A24A',
    marginTop: 4,
  },
  panelText: {
    color: '#94A3B8',
    fontSize: 13,
    marginTop: 4,
  },
  content: {
    flex: 1,
    paddingHorizontal: 24,
    paddingTop: 22,
  },
});